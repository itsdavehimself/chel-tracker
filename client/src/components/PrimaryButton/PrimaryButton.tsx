import styles from './PrimaryButton.module.scss';

interface PrimaryButtonProps {
    text: string;
}

const PrimaryButton: React.FC<PrimaryButtonProps> = ({ text }) => {
    return <button className={styles['primary-btn']}>{text}</button>;
};

export default PrimaryButton;
