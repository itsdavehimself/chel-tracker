import styles from './Dashboard.module.scss';
import PrimaryButton from '../../components/PrimaryButton/PrimaryButton';

const Dashboard: React.FC = () => {
    return (
        <main className={styles.dashboard}>
            <PrimaryButton text="Add Opponent"></PrimaryButton>
        </main>
    );
};

export default Dashboard;
