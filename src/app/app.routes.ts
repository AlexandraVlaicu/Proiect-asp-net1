import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home.component';
import { ListaProduseComponent } from './components/listaproduse.component';
import { DetaliiProdusComponent } from './components/detaliiprodus.component';
import { AuthGuard } from './login/autentificare.guard';
import { LoginComponent } from './login/login.component';

export const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'produse', component: ListaProduseComponent },
  { path: 'produs/:id', component: DetaliiProdusComponent },
  { path: 'login', component: LoginComponent },
  {
    path: 'dashboard',
    loadChildren: () => import('./models/dashboard.module').then((m) => m.DashboardModule),
    canActivate: [AuthGuard],
  },
  { path: '', redirectTo: '/login', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
