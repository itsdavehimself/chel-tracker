import styles from './Navbar.module.scss';
import { useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faBars, faXmark } from '@fortawesome/free-solid-svg-icons';
import useLogOut from '../../hooks/useLogout';
import { useAuthContext } from '../../hooks/useAuthContext';

const Navbar: React.FC = () => {
    const [isMenuOpen, setIsMenuOpen] = useState<boolean>(false);

    const barsIcon: React.ReactNode = <FontAwesomeIcon icon={faBars} />;
    const xIcon: React.ReactNode = <FontAwesomeIcon icon={faXmark} />;

    const { user } = useAuthContext();
    const { logOut } = useLogOut();
    const navigate = useNavigate();

    const handleSignOut = (): void => {
        setIsMenuOpen(false);
        logOut();
        navigate('login');
    };

    const handleSignIn = (): void => {
        setIsMenuOpen(false);
        navigate('login');
    };

    return (
        <>
            {isMenuOpen && (
                <div className={styles['navbar-menu-modal']}>
                    <div className={styles['btn-bar']}>
                        <button
                            className={styles['modal-btn']}
                            onClick={() => setIsMenuOpen(false)}
                        >
                            {xIcon}
                        </button>
                    </div>
                    <div className={styles['menu-items']}>
                        <Link
                            to="/dashboard"
                            onClick={() => setIsMenuOpen(false)}
                        >
                            HOME
                        </Link>
                        <Link to="/about" onClick={() => setIsMenuOpen(false)}>
                            ABOUT
                        </Link>
                        {user ? (
                            <button
                                className={styles['modal-nav-btn']}
                                onClick={handleSignOut}
                            >
                                SIGN OUT
                            </button>
                        ) : (
                            <button
                                className={styles['modal-nav-btn']}
                                onClick={handleSignIn}
                            >
                                SIGN IN
                            </button>
                        )}
                    </div>
                </div>
            )}
            <nav className={styles.navbar}>
                <div className={styles.logo}>CHELTRACKER</div>
                <button
                    className={styles['modal-btn']}
                    onClick={() => setIsMenuOpen(true)}
                >
                    {barsIcon}
                </button>
            </nav>
        </>
    );
};

export default Navbar;
