import {bootstrapApplication, provideProtractorTestingSupport} from '@angular/platform-browser';
import {AppComponent} from './app/app.component';
import {provideRouter} from '@angular/router';
import { provideHttpClient } from '@angular/common/http';
import routeConfig from './app/routes';

bootstrapApplication(AppComponent, {
  providers: [
    provideProtractorTestingSupport(), 
    provideRouter(routeConfig),
    provideHttpClient()
  ],
}).catch((err) => console.error(err));
