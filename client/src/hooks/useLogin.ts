import { useState } from 'react';
import { useAuthContext } from './useAuthContext';

const API_BASE_URL: string = 'http://localhost:5042/api';

interface LoginResult {
    login: (email: string, password: string) => Promise<void>;
    isLoading: boolean;
    error: Error | null;
}

const useLogin = (): LoginResult => {
    const [error, setError] = useState<Error | null>(null);
    const [isLoading, setIsLoading] = useState<boolean>(false);
    const { dispatch } = useAuthContext();

    const login = async (username: string, password: string): Promise<void> => {
        setIsLoading(true);
        setError(null);

        const loginResponse = await fetch(`${API_BASE_URL}/user/login`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({ username, password }),
        });

        const loginJSON = await loginResponse.json();

        if (!loginResponse.ok) {
            setIsLoading(false);
            setError(loginJSON.error);
        }

        if (loginResponse.ok) {
            localStorage.setItem('user', JSON.stringify(loginJSON));
            dispatch({ type: 'LOGIN', payload: loginJSON });
            setIsLoading(false);
            setError(null);
        }
    };

    return { login, isLoading, error };
};

export default useLogin;
