import styles from './Navbar.module.scss';

const Navbar: React.FC = () => {
    return (
        <nav className={styles.navbar}>
            <div>ChelTracker</div>
        </nav>
    );
};

export default Navbar;
