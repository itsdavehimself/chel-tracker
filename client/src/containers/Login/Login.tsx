import AuthBtn from '../../components/AuthBtn/AuthBtn';
import AuthInput from '../../components/AuthInput/AuthInput';
import styles from './Login.module.scss';
import { Link } from 'react-router-dom';
import { useState } from 'react';
import useLogin from '../../hooks/useLogin';

const Login: React.FC = () => {
    const [username, setUsername] = useState<string>('');
    const [password, setPassword] = useState<string>('');
    const { login } = useLogin();

    const handleLogin = (e: React.FormEvent): void => {
        e.preventDefault();
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
                    />
                    <AuthInput
                        label="Password"
                        inputIdentifier="password"
                        type="password"
                        onChange={(e) => setPassword(e.target.value)}
                    />
                    <div className={styles['auth-btns']}>
                        <AuthBtn label="Login" />
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
