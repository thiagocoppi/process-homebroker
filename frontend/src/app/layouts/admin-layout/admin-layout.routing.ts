import { AcoesComponent } from './../../pages/acoes/acoes.component';
import { Routes } from '@angular/router';

import { DashboardComponent } from '../../pages/dashboard/dashboard.component';

export const AdminLayoutRoutes: Routes = [
    { path: 'dashboard',      component: DashboardComponent },    
    { path: 'acoes',          component: AcoesComponent }
    
];
