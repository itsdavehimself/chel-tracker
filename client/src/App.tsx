import { BrowserRouter, Routes, Route } from 'react-router-dom';
import './App.scss';
import Dashboard from './containers/Dashboard/Dashboard';
import Login from './containers/Login/Login';
import Navbar from './components/Navbar/Navbar';
import SignUp from './containers/SignUp/SignUp';
import OpponentOverview from './containers/OpponentOverview/OpponentOverview';
import { useAuthContext } from './hooks/useAuthContext';

function App() {
    const { user } = useAuthContext();
    return (
        <>
            <BrowserRouter>
                <Navbar />
                <Routes>
                    <Route
                        path="/login"
                        element={!user ? <Login /> : <Dashboard />}
                    />
                    <Route
                        path="/signup"
                        element={!user ? <SignUp /> : <Dashboard />}
                    />
                    <Route
                        path="/dashboard"
                        element={user ? <Dashboard /> : <Login />}
                    />
                    <Route
                        path="/opponent/:opponentId"
                        element={user ? <OpponentOverview /> : <Login />}
                    />
                </Routes>
            </BrowserRouter>
        </>
    );
}

export default App;
