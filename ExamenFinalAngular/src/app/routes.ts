import { Routes } from '@angular/router';
import { PageNotFoundComponent } from './pages/page-not-found/page-not-found.component';
import { LoginComponent } from './pages/login/login.component';
import { RegisterComponent } from './pages/register/register.component';
import { PrincipalComponent } from './pages/principal/prinicpal.component';
import { ObjetoPageComponent } from './pages/objeto-page/objeto-page.component';
import { AnadirComponent } from './pages/anadir/anadir.component';

const routeConfig: Routes = [
  {
    path: '',
    component: LoginComponent,
    title: 'login page',
  },
  {
    path: 'registro',
    component: RegisterComponent,
    title: 'registro',
  },
  {
    path: 'principal',
    component: PrincipalComponent,
  },
  {
    path: 'objetoPage/:id',
    component: ObjetoPageComponent,
    title: 'objetoIndividual'
  },
  {
    path: 'anadir',
    component: AnadirComponent,
    title: 'anadirComponent'
  },
  {
    path: '**',
    component: PageNotFoundComponent,
  },
];

export default routeConfig;
