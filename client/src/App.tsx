import { BrowserRouter, Routes, Route, Navigate } from 'react-router-dom';
import './App.scss';
import Dashboard from './containers/Dashboard/Dashboard';
import Login from './containers/Login/Login';
import Navbar from './containers/Navbar/Navbar';

function App() {
    return (
        <>
            <BrowserRouter>
                <Navbar />
                <Routes>
                    <Route path="/login" element={<Login />} />
                    <Route path="/dashboard" element={<Dashboard />} />
                </Routes>
            </BrowserRouter>
        </>
    );
}

export default App;
