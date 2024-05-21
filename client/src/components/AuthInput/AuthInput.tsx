import styles from './AuthInput.module.scss';

interface AuthInputProps {
    label: string;
    inputIdentifier: string;
    type: string;
}

const AuthInput: React.FC<AuthInputProps> = ({
    label,
    inputIdentifier,
    type,
}) => {
    return (
        <div className={styles['auth-input']}>
            <label htmlFor={inputIdentifier}>{label}</label>
            <input
                type={type}
                id={inputIdentifier}
                name={inputIdentifier}
                placeholder={label}
            ></input>
        </div>
    );
};

export default AuthInput;
