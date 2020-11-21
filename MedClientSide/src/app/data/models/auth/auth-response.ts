export class AuthResponse {
  token: string;
  refreshToken: string;
  success: boolean;
  errorMessages: string[];
  username: string;
  userId: string;
}
