import { useState } from 'react';
import { useAuthContext } from './useAuthContext';

const API_BASE_URL: string =
    import.meta.env.VITE_API_BASE_URL || 'http://localhost:5042/api';

interface SignUpResult {
    signUp: (
        username: string,
        email: string,
        password: string
    ) => Promise<void>;
    isLoading: boolean;
    error: ErrorObject;
}

export interface ErrorObject {
    [key: string]: string[];
}

const useSignUp = (): SignUpResult => {
    const [error, setError] = useState<ErrorObject>({});
    const [isLoading, setIsLoading] = useState<boolean>(false);
    const { dispatch } = useAuthContext();

    const signUp = async (
        username: string,
        email: string,
        password: string
    ): Promise<void> => {
        setIsLoading(true);
        setError({});

        const signUpResponse = await fetch(`${API_BASE_URL}/user/register`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                username,
                email,
                password,
            }),
        });

        const signUpJSON = await signUpResponse.json();

        if (!signUpResponse.ok) {
            setIsLoading(false);
            console.log(signUpJSON.errors);
            setError(signUpJSON.errors);
        }

        if (signUpResponse.ok) {
            localStorage.setItem('user', JSON.stringify(signUpJSON));
            dispatch({ type: 'LOGIN', payload: signUpJSON });
            setIsLoading(false);
            setError({});
        }
    };

    return { signUp, isLoading, error };
};

export default useSignUp;
