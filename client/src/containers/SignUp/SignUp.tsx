import styles from './SignUp.module.scss';
import AuthInput from '../../components/AuthInput/AuthInput';
import AuthBtn from '../../components/AuthBtn/AuthBtn';
import { Link } from 'react-router-dom';

const SignUp: React.FC = () => {
    return (
        <div className={styles.auth}>
            <div className={styles['auth-container']}>
                <h1>Let's get you a twig and all laced up.</h1>
                <form className={styles['auth-form']}>
                    <h2>Sign Up</h2>
                    <AuthInput
                        label="Username"
                        inputIdentifier="username"
                        type="text"
                    />
                    <AuthInput
                        label="Email"
                        inputIdentifier="email"
                        type="email"
                    />
                    <AuthInput
                        label="Password"
                        inputIdentifier="password"
                        type="password"
                    />
                    <div className={styles['auth-btns']}>
                        <AuthBtn label="Sign Up" />
                    </div>
                    <div className={styles['signup-container']}>
                        Already got a bucket? <Link to="/login">Login</Link>
                    </div>
                </form>
            </div>
        </div>
    );
};

export default SignUp;
