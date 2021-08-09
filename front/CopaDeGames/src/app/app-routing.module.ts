import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CampeoesComponent } from './components/campeoes/campeoes.component';
import { CampeonatoComponent } from './components/campeonato/campeonato.component';

const routes: Routes = [
  { path: '', redirectTo: 'campeonato', pathMatch: 'full' },
  { path: 'campeonato', component: CampeonatoComponent  },
  { path: 'campeoes/:id', component: CampeoesComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
