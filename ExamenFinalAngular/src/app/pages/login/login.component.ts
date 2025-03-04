import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../service/Auth.service';
import { LoginDTO } from '../../models/loginDTO';
import { firstValueFrom } from 'rxjs';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-login',
  imports: [FormsModule, CommonModule],
  standalone: true,
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  username: string = 'Admin';
  password: string = 'ADMINadmin10.';

  constructor(private authService: AuthService, private router: Router) {}

  async login() {
    const loginDto: LoginDTO = {
      username: this.username, 
      password: this.password,
      token: ''
    };
    try {
      const response = await firstValueFrom(this.authService.login(loginDto));
      if (response?.result?.token) {
        localStorage.setItem('token', response.result.token);
        this.router.navigate(['/principal']);
      } else {
        alert('Error: Usuario o contraseña incorrectos.');
      }      
    } catch (error: any) {
      alert(error.message);
    }
  }

  goToRegister() {
    this.router.navigate(['/registro']);
  }
}