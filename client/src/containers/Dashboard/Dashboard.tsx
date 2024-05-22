import styles from './Dashboard.module.scss';
import PrimaryButton from '../../components/PrimaryButton/PrimaryButton';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faPlus } from '@fortawesome/free-solid-svg-icons';
import LatestGame from '../../components/LatestGame/LatestGame';
import { useEffect, useState } from 'react';
import { useAuthContext } from '../../hooks/useAuthContext';
import OpponentCard from '../../components/OpponentCard/OpponentCard';
import LargeLoadingSpinner from '../../components/LargeLoadingSpinner/LargeLoadingSpinner';

const API_BASE_URL: string =
    import.meta.env.VITE_API_BASE_URL || 'http://localhost:5042/api/';

export type OpponentInfo = {
    name: string;
    id: number;
};

export type GameInfo = {
    userScore: number;
    opponentScore: number;
    date: string;
};

export interface Opponent {
    opponent: OpponentInfo;
    games: GameInfo[];
}

const Dashboard: React.FC = () => {
    const plusIcon: React.ReactNode = <FontAwesomeIcon icon={faPlus} />;
    const { user } = useAuthContext();
    const [isLoading, setIsLoading] = useState<boolean>(true);
    const [error, setError] = useState<Error | null>(null);
    const [opponentsInfo, setOpponentsInfo] = useState<Opponent[]>([]);

    useEffect(() => {
        const fetchOpponents = async (): Promise<void> => {
            const opponentsResponse = await fetch(
                `${API_BASE_URL}opponent/user/${user?.id}/opponents-with-stats`,
                {
                    method: 'GET',
                    headers: {
                        Authorization: `Bearer ${user?.token}`,
                        'Content-Type': 'application/json',
                    },
                }
            );

            const opponentsJSON = await opponentsResponse.json();

            if (!opponentsResponse.ok) {
                setIsLoading(false);
                setError(opponentsJSON.error);
            }

            if (opponentsResponse.ok) {
                setIsLoading(false);
                setError(null);
                setOpponentsInfo(opponentsJSON);
            }
        };

        fetchOpponents();
    }, [user]);

    return (
        <main className={styles.dashboard}>
            {isLoading ? (
                <LargeLoadingSpinner />
            ) : error ? (
                <div>
                    There was an error loading the opponents. Please try again
                    in a little bit.
                </div>
            ) : (
                <>
                    <LatestGame />
                    <h2 className={styles['opponents-title']}>
                        Your Opponents
                    </h2>
                    <PrimaryButton icon={plusIcon} text="ADD OPPONENT" />
                    <div className={styles['opponent-cards']}>
                        {opponentsInfo.map((opponent, index) => (
                            <OpponentCard
                                opponent={opponent.opponent}
                                games={opponent.games}
                                key={index}
                            />
                        ))}
                    </div>
                </>
            )}
        </main>
    );
};

export default Dashboard;
