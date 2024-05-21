import AuthBtn from '../../components/AuthBtn/AuthBtn';
import AuthInput from '../../components/AuthInput/AuthInput';
import styles from './Login.module.scss';
import { Link } from 'react-router-dom';

const Login: React.FC = () => {
    return (
        <div className={styles.login}>
            <div className={styles['auth-container']}>
                <h1>Welcome back to the barn, ya beauty.</h1>
                <form className={styles['auth-form']}>
                    <h2>Login</h2>
                    <AuthInput
                        label="Username"
                        inputIdentifier="username"
                        type="text"
                    />
                    <AuthInput
                        label="Password"
                        inputIdentifier="password"
                        type="password"
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
