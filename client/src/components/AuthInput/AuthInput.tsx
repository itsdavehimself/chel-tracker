import styles from './AuthInput.module.scss';

interface AuthInputProps {
    label: string;
    inputIdentifier: string;
    type: string;
    onChange: (e: React.ChangeEvent<HTMLInputElement>) => void;
}

const AuthInput: React.FC<AuthInputProps> = ({
    label,
    inputIdentifier,
    type,
    onChange,
}) => {
    return (
        <div className={styles['auth-input']}>
            <label htmlFor={inputIdentifier}>{label}</label>
            <input
                type={type}
                id={inputIdentifier}
                name={inputIdentifier}
                placeholder={label}
                onChange={onChange}
            ></input>
        </div>
    );
};

export default AuthInput;
