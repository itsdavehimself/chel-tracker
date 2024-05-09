import styles from './Dashboard.module.scss';
import PrimaryButton from '../../components/PrimaryButton/PrimaryButton';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faPlus } from '@fortawesome/free-solid-svg-icons';

const Dashboard: React.FC = () => {
    const plusIcon: React.ReactNode = <FontAwesomeIcon icon={faPlus} />;

    return (
        <main className={styles.dashboard}>
            <PrimaryButton icon={plusIcon} text="ADD OPPONENT"></PrimaryButton>
        </main>
    );
};

export default Dashboard;
