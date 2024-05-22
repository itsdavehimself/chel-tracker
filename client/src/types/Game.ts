export type Game = {
    id: string;
    date: string;
    userTeam: string;
    opponentTeam: string;
    difficulty: string;
    userScore: number;
    opponentScore: number;
    userShots: number;
    opponentShots: number;
    userHits: number;
    opponentHits: number;
    userTimeOnAttack: number;
    opponentTimeOnAttack: number;
    userPassingPercentage: number;
    opponentPassingPercentage: number;
    userFaceOffWins: number;
    opponentFaceOffWins: number;
    userPenaltyMinutes: number;
    opponentPenaltyMinutes: number;
    userPowerPlayPercentage: number;
    opponentPowerPlayPercentage: number;
    userPowerPlayMinutes: number;
    opponentPowerPlayMinutes: number;
    userShortHandedGoals: number;
    opponentShortHandedGoals: number;
};