import styles from './GameCard.module.scss';
import { Game } from '../../types/Game';
import formatDate from '../../helpers/formatDate';

interface GameCardProps {
    game: Game;
}

const GameCard: React.FC<GameCardProps> = ({ game }) => {
    return (
        <div className={styles['game-card']}>
            <div className={styles.date}>{formatDate(game.date)}</div>
            <div className={styles.scores}>
                <div className={styles['game-info']}>
                    <div className={styles.team}>{game.userTeam}</div>
                    <div className={styles.score}>{game.userScore}</div>
                </div>
                <div className={styles.final}>FINAL</div>
                <div className={styles['game-info']}>
                    <div className={styles.team}>{game.opponentTeam}</div>
                    <div className={styles.score}>{game.opponentScore}</div>
                </div>
            </div>
        </div>
    );
};

export default GameCard;
