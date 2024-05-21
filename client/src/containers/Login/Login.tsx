import AuthBtn from '../../components/AuthBtn/AuthBtn';
import AuthInput from '../../components/AuthInput/AuthInput';
import styles from './Login.module.scss';
import { Link } from 'react-router-dom';
import { useState } from 'react';
import useLogin from '../../hooks/useLogin';

const Login: React.FC = () => {
    const [username, setUsername] = useState<string>('');
    const [usernameError, setUsernameError] = useState<boolean>(false);
    const [password, setPassword] = useState<string>('');
    const [passwordError, setPasswordError] = useState<boolean>(false);
    const { login, isLoading, error } = useLogin();

    const checkUsername = () => {
        setUsernameError(username === '');
    };

    const checkPassword = () => {
        setPasswordError(password === '');
    };

    const handleLogin = (e: React.FormEvent): void => {
        e.preventDefault();
        setUsernameError(false);
        setPasswordError(false);
        if (!username || !password) {
            checkUsername();
            checkPassword();
            return;
        }
        login(username, password);
    };

    return (
        <div className={styles.auth}>
            <div className={styles['auth-container']}>
                <h1>Welcome back to the barn, ya beauty.</h1>
                <form className={styles['auth-form']} onSubmit={handleLogin}>
                    <h2>Login</h2>
                    <AuthInput
                        label="Username"
                        inputIdentifier="username"
                        type="text"
                        onChange={(e) => setUsername(e.target.value)}
                        error={usernameError}
                    />
                    <AuthInput
                        label="Password"
                        inputIdentifier="password"
                        type="password"
                        onChange={(e) => setPassword(e.target.value)}
                        error={passwordError}
                    />
                    <div className={styles['auth-btns']}>
                        <AuthBtn label="Login" isLoading={isLoading} />
                    </div>
                    <div className={styles.error}>
                        {error && !usernameError && !passwordError
                            ? error.message
                            : usernameError || passwordError
                              ? 'Please fill out all fields.'
                              : ''}
                    </div>
                    <div className={styles['signup-container']}>
                        Still have all your teeth?{' '}
                        <Link to="/signup">Sign up</Link>
                    </div>
                </form>
            </div>
        </div>
    );
};

export default Login;
