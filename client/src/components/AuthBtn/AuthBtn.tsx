import styles from './AuthBtn.module.scss';

interface AuthBtnProps {
    label: string;
    isLoading: boolean;
}

const AuthBtn: React.FC<AuthBtnProps> = ({ label, isLoading }) => {
    return (
        <button className={styles['auth-btn']} disabled={isLoading}>
            {isLoading ? (
                <span className={styles['loading-spinner']}></span>
            ) : (
                label
            )}
        </button>
    );
};

export default AuthBtn;
