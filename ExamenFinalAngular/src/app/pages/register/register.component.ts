import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../service/Auth.service';
import { RegistroDTO } from '../../models/registroDTO';
import { firstValueFrom } from 'rxjs';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
  standalone: true,
  imports: [FormsModule, CommonModule]
})
export class RegisterComponent {
  username: string = '';
  email: string = '';
  password: string = '';
  confirmPassword: string = '';

  constructor(private authService: AuthService, private router: Router) {}

  async register() {
    if (!this.username || !this.email || !this.password || !this.confirmPassword) {
      alert('Todos los campos son obligatorios.');
      return;
    }

    if (this.password !== this.confirmPassword) {
      alert('Las contraseñas no coinciden.');
      return;
    }

    const registroDto: RegistroDTO = {
      name: this.username,
      userName: this.username,
      email: this.email,
      password: this.password,
      role: 'admin'
    };

    try {
      await firstValueFrom(this.authService.register(registroDto));
      alert('Usuario registrado con éxito');
      this.router.navigate(['/']);
    } catch (error: any) {
      alert(error.message);
    }
  }

  goToLogin() {
    this.router.navigate(['/']);
  }
}