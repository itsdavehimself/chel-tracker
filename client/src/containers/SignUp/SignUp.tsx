import styles from './SignUp.module.scss';
import AuthInput from '../../components/AuthInput/AuthInput';
import AuthBtn from '../../components/AuthBtn/AuthBtn';
import { Link } from 'react-router-dom';
import { useEffect, useState } from 'react';
import useSignUp from '../../hooks/useSignUp';
import { ErrorObject } from '../../hooks/useSignUp';

const SignUp: React.FC = () => {
    const [username, setUsername] = useState<string>('');
    const [usernameEmpty, setUsernameEmpty] = useState<boolean>(false);
    const [usernameErrorsArray, setUsernameErrorsArray] = useState<string[]>(
        []
    );
    const [email, setEmail] = useState<string>('');
    const [emailEmpty, setEmailEmpty] = useState<boolean>(false);
    const [emailErrorsArray, setEmailErrorsArray] = useState<string[]>([]);
    const [password, setPassword] = useState<string>('');
    const [passwordEmpty, setPasswordEmpty] = useState<boolean>(false);
    const [passwordErrorsArray, setPasswordErrorsArray] = useState<string[]>(
        []
    );
    const { signUp, isLoading, error } = useSignUp();

    const checkUsername = () => {
        setUsernameEmpty(username === '');
    };

    const checkPassword = () => {
        setPasswordEmpty(password === '');
    };

    const checkEmail = () => {
        setEmailEmpty(email === '');
    };

    const processServerErrors = (error: ErrorObject) => {
        setUsernameErrorsArray(error.Username);
        setEmailErrorsArray(error.Email);
        setPasswordErrorsArray(error.Password);
    };

    const handleSignUp = async (e: React.FormEvent): Promise<void> => {
        e.preventDefault();
        setPasswordErrorsArray([]);
        setUsernameErrorsArray([]);
        setEmailErrorsArray([]);
        setUsernameEmpty(false);
        setPasswordEmpty(false);
        setEmailEmpty(false);
        if (!username || !password) {
            checkUsername();
            checkPassword();
            checkEmail();
            return;
        }
        signUp(username, email, password);
    };

    useEffect(() => {
        processServerErrors(error);
    }, [error]);

    return (
        <div className={styles.auth}>
            <div className={styles['auth-container']}>
                <h1>Let's get you a twig and all laced up.</h1>
                <form
                    className={styles['auth-form']}
                    onSubmit={handleSignUp}
                    noValidate
                >
                    <h2>Sign Up</h2>
                    <AuthInput
                        label="Username"
                        inputIdentifier="username"
                        type="text"
                        onChange={(e) => setUsername(e.target.value)}
                        error={usernameEmpty || usernameErrorsArray?.length > 0}
                        errorArray={usernameErrorsArray}
                    />
                    <AuthInput
                        label="Email"
                        inputIdentifier="email"
                        type="email"
                        onChange={(e) => setEmail(e.target.value)}
                        error={emailEmpty || emailErrorsArray?.length > 0}
                        errorArray={emailErrorsArray}
                    />
                    <AuthInput
                        label="Password"
                        inputIdentifier="password"
                        type="password"
                        onChange={(e) => setPassword(e.target.value)}
                        error={passwordEmpty || passwordErrorsArray?.length > 0}
                        errorArray={passwordErrorsArray}
                    />
                    <div className={styles['auth-btns']}>
                        <AuthBtn label="Sign Up" isLoading={isLoading} />
                    </div>
                    <div className={styles.error}>
                        {usernameEmpty || passwordEmpty || emailEmpty
                            ? 'Please fill out all fields.'
                            : ''}
                    </div>
                    <div className={styles.error}></div>
                    <div className={styles['signup-container']}>
                        Already got a bucket? <Link to="/login">Login</Link>
                    </div>
                </form>
            </div>
        </div>
    );
};

export default SignUp;
