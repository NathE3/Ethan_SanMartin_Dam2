import {Component} from '@angular/core';
import {RouterModule} from '@angular/router';
import {RouterOutlet} from '@angular/router';
import { FerrariLocationsComponent } from './components/ferrrari-component/ferrari-component.component';

@Component({
  selector: 'app-root',
  imports: [RouterModule, FerrariLocationsComponent,RouterOutlet ],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'Me quiero morir';
}
