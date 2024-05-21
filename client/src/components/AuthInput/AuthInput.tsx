import styles from './AuthInput.module.scss';

interface AuthInputProps {
    label: string;
    inputIdentifier: string;
    type: string;
    onChange: (e: React.ChangeEvent<HTMLInputElement>) => void;
    error: boolean;
    errorArray?: string[];
}

const AuthInput: React.FC<AuthInputProps> = ({
    label,
    inputIdentifier,
    type,
    onChange,
    error,
    errorArray,
}) => {
    return (
        <div className={styles['auth-input']}>
            <label htmlFor={inputIdentifier}>{label}</label>
            <input
                className={`${error ? styles.error : ''}`}
                type={type}
                id={inputIdentifier}
                name={inputIdentifier}
                placeholder={label}
                onChange={onChange}
            ></input>
            {errorArray ? (
                <div className={styles['error-text']}>
                    {errorArray?.map((error, index) => (
                        <div key={index}>{error}</div>
                    ))}
                </div>
            ) : (
                ''
            )}
        </div>
    );
};

export default AuthInput;
