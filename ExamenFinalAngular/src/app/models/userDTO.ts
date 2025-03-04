export interface UserDTO {
    statusCode: number;
    isSuccess: boolean;
    errorMessages: any[];
    result: Result;
}

export interface Result {
    token: string;
}