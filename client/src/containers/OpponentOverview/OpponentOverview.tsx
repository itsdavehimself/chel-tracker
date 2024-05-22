import styles from './OpponentOverview.module.scss';
import { useEffect, useState } from 'react';
import { useAuthContext } from '../../hooks/useAuthContext';
import { Game } from '../../types/Game';
import { useParams } from 'react-router-dom';
import GameCard from '../../components/GameCard/GameCard';

const API_BASE_URL: string =
    import.meta.env.VITE_API_BASE_URL || 'http://localhost:5042/api/';

const OpponentOverview: React.FC = () => {
    const { user } = useAuthContext();
    const { opponentId } = useParams();
    const [isLoading, setIsLoading] = useState<boolean>(true);
    const [error, setError] = useState<Error | null>(null);
    const [games, setGames] = useState<Game[]>();

    useEffect(() => {
        const fetchGames = async (): Promise<void> => {
            const gamesResponse = await fetch(
                `${API_BASE_URL}game?userId=${user?.id}&opponentId=${opponentId}`,
                {
                    method: 'GET',
                    headers: {
                        Authorization: `Bearer ${user?.token}`,
                        'Content-Type': 'application/json',
                    },
                }
            );

            const gamesJSON = await gamesResponse.json();

            if (!gamesResponse.ok) {
                setIsLoading(false);
                setError(gamesJSON.error);
            }

            if (gamesResponse.ok) {
                setIsLoading(false);
                setError(null);
                setGames(gamesJSON);
            }
        };

        fetchGames();
    }, [user]);
    return (
        <div className={styles['opponent-overview']}>
            <h2 className={styles['section-title']}>GAME HISTORY</h2>
            {games?.map((game, index) => <GameCard game={game} key={index} />)}
        </div>
    );
};

export default OpponentOverview;
