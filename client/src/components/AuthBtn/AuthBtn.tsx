import styles from './AuthBtn.module.scss';

interface AuthBtnProps {
    label: string;
}

const AuthBtn: React.FC<AuthBtnProps> = ({ label }) => {
    return <button className={styles['auth-btn']}>{label}</button>;
};

export default AuthBtn;
