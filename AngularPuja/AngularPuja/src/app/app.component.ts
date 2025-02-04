import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { RouterModule } from '@angular/router';
import { FerrariComponent } from './ferrari/ferrari.component';

@Component({
selector: 'app-root',
imports: [RouterOutlet,RouterModule],
templateUrl: './app.component.html',
styleUrl: './app.component.css'
})
export class AppComponent {
title = 'homes';
}
