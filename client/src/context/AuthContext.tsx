import {
    Dispatch,
    useEffect,
    useReducer,
    createContext,
    ReactNode,
} from 'react';
import { AuthAction } from '../types/AuthActionType';
import { authReducer } from '../reducers/AuthReducer';

export interface UserType {
    email: string;
    id: string;
    username: string;
    token: string;
}

interface AuthContextType {
    dispatch: Dispatch<AuthAction>;
    user: UserType | null;
}

const AuthContext = createContext<AuthContextType | null>(null);

const AuthContextProvider = ({ children }: { children: ReactNode }) => {
    const [state, dispatch] = useReducer(authReducer, {
        user: null,
    });

    useEffect(() => {
        const storedUser = localStorage.getItem('user');

        if (storedUser) {
            const user = JSON.parse(storedUser);
            dispatch({ type: 'LOGIN', payload: user });
        }
    }, []);

    console.log('AuthContext state', state);
    return (
        <AuthContext.Provider value={{ ...state, dispatch }}>
            {children}
        </AuthContext.Provider>
    );
};

export { AuthContext, AuthContextProvider };
