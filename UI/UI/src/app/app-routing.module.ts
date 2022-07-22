import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { AuthGuard } from './guards/auth.guard';
import { HomeComponent } from './home/home.component';
import { MatchesListComponent } from './matches/matches-list/matches-list.component';
import { CreateMatchComponent } from './matches/create-match/create-match.component';
import { PlayerListComponent } from './players/player-list/player-list.component';
import { CreatePlayerComponent } from './players/create-player/create-player.component';
import { PlayerMatchesComponent } from './players/player-matches/player-matches.component';
import { UpdatePlayerComponent } from './players/update-player/update-player.component';
import { RankingComponent } from './ranking/ranking.component';
import { RegisterComponent } from './register/register.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      { path: 'players', component: PlayerListComponent },
      { path: 'ranking', component: RankingComponent },
      { path: 'matches', component: MatchesListComponent },
      { path: 'players/create', component: CreatePlayerComponent },
      { path: 'matches/create', component: CreateMatchComponent },
      { path: 'players/update/:username', component: UpdatePlayerComponent },
      { path: 'players/:username/matches', component: PlayerMatchesComponent },
    ]
  },
  { path: 'register', component: RegisterComponent },
  { path: 'not-found', component: NotFoundComponent },
  { path: '**', component: HomeComponent, pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
