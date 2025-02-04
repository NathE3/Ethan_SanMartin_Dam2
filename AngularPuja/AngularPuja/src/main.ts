import { bootstrapApplication } from '@angular/platform-browser';
import { appConfig } from './app/app.config';
import { provideRouter } from '@angular/router';
import { provideHttpClient } from '@angular/common/http';
import routeConfig from './app/routes';
import { AppComponent } from './app/app.component';

bootstrapApplication(AppComponent, {
providers: [
provideRouter(routeConfig),
provideHttpClient(),
]
}).catch(err => console.error(err));