export interface Match {
    id: string;
    playerOneUserName: string;
    playerTwoUserName: string;
    score: string;
    playerOneCenturyBreaks: number;
    playerTwoCenturyBreaks: number;
    playerOneHalfCenturyBreaks: number;
    playerTwoHalfCenturyBreaks: number;
    playerOneMaximums: number;
    playerTwoMaximums: number;
    createdOn: Date;
    description: string;
}