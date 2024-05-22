import styles from './OpponentCard.module.scss';
import { OpponentInfo, GameInfo } from '../../containers/Dashboard/Dashboard';
import { useEffect, useState } from 'react';
import formatDate from '../../helpers/formatDate';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faAngleRight } from '@fortawesome/free-solid-svg-icons';
import { useNavigate } from 'react-router-dom';

interface OpponentCardProps {
    opponent: OpponentInfo;
    games: GameInfo[];
}

const OpponentCard: React.FC<OpponentCardProps> = ({ opponent, games }) => {
    const [userWins, setUserWins] = useState<number>(0);
    const [userLosses, setUserLosses] = useState<number>(0);
    const [ties, setTies] = useState<number>(0);
    const [latestGameIndex, setLatestGameIndex] = useState<number>(0);

    const navigate = useNavigate();

    const rightArrow: React.ReactNode = <FontAwesomeIcon icon={faAngleRight} />;

    const calculateRecord = (games: GameInfo[]): void => {
        let wins = 0;
        let losses = 0;
        let ties = 0;

        for (let i = 0; i < games.length; i += 1) {
            if (games[i]?.userScore > games[i]?.opponentScore) {
                wins += 1;
            } else if (games[i]?.userScore < games[i]?.opponentScore) {
                losses += 1;
            } else ties += 1;
        }

        setUserWins(wins);
        setUserLosses(losses);
        setTies(ties);
    };

    useEffect(() => {
        calculateRecord(games);
        setLatestGameIndex(games.length - 1);
    }, []);

    return (
        <div
            className={styles['opponent-card']}
            onClick={() => navigate(`/opponent/${opponent.opponentId}`)}
        >
            <div className={styles.record}>
                <div className={styles.name}>{opponent.name.toUpperCase()}</div>
                <div>
                    ({userWins}-{userLosses}-{ties})
                </div>
            </div>
            <div className={styles['latest-game']}>
                <div className={styles['latest-title']}>
                    LATEST GAME:{' '}
                    <span className={styles.date}>
                        {formatDate(games[latestGameIndex].date)}
                    </span>
                </div>
                <div>
                    {games[latestGameIndex].userScore} -{' '}
                    {games[latestGameIndex].opponentScore}{' '}
                    {games[latestGameIndex].userScore >
                    games[latestGameIndex].opponentScore ? (
                        <span className={styles.win}>(W)</span>
                    ) : (
                        <span className={styles.loss}>(L)</span>
                    )}
                </div>
            </div>
            <div className={styles['card-arrow']}>{rightArrow}</div>
        </div>
    );
};

export default OpponentCard;
