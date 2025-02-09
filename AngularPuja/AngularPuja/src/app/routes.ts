import {Routes} from '@angular/router';
import { HomeComponent } from './Pages/home/home/home.component';
import { DetailsComponent } from './Pages/details/details/details.component';
import { NotFoundComponent } from './Pages/not-found/not-found/not-found.component';
import { BidComponent} from './Pages/bid/bid.component';

const routeConfig: Routes = [
    {
      path: '',
      component: HomeComponent,
      title: 'Home page',
    },
    {
      path: 'details/:id',
      component: DetailsComponent,
      title: 'Ferrari details',
    },
    {
      path: '**',
      component: NotFoundComponent,
    },

    {
      path: 'bid/:id',
      component: BidComponent,
      title: 'Pagina Puja',
    },


  ];
  export default routeConfig;
