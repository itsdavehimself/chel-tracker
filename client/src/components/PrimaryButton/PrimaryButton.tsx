import styles from './PrimaryButton.module.scss';

interface PrimaryButtonProps {
    text: string;
    icon: React.ReactNode;
}

const PrimaryButton: React.FC<PrimaryButtonProps> = ({ icon, text }) => {
    return (
        <button className={styles['primary-btn']}>
            {icon}
            {text}
        </button>
    );
};

export default PrimaryButton;
