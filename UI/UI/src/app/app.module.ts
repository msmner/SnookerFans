import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ErrorInterceptor } from './interceptors/error.interceptor';
import { FormsModule, ReactiveFormsModule }   from '@angular/forms';
import { CommonModule } from '@angular/common';
import { NavComponent } from './nav/nav.component'; 
import { TextInputComponent } from './forms/text-input/text-input.component';
import { RegisterComponent } from './register/register.component';
import { HomeComponent } from './home/home.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SharedModule } from './modules/shared.module';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { AuthInterceptor } from './interceptors/auth.interceptor';
import { HasRoleDirective } from './directives/has-role.directive';
import { PlayerListComponent } from './players/player-list/player-list.component';
import { MatchesListComponent } from './matches/matches-list/matches-list.component';
import { MatchCardComponent } from './matches/match-card/match-card.component';
import { PlayerCardComponent } from './players/player-card/player-card.component';
import { CreatePlayerComponent } from './players/create-player/create-player.component';
import { CreateMatchComponent } from './matches/create-match/create-match.component';
import { UpdatePlayerComponent } from './players/update-player/update-player.component';
import { RankingComponent } from './ranking/ranking.component';
import { PlayerMatchesComponent } from './players/player-matches/player-matches.component';

@NgModule({
  declarations: [
    AppComponent,
    RegisterComponent,
    NavComponent,
    TextInputComponent,
    HomeComponent,
    NotFoundComponent,
    ServerErrorComponent,
    HasRoleDirective,
    PlayerListComponent,
    MatchesListComponent,
    MatchCardComponent,
    PlayerCardComponent,
    CreatePlayerComponent,
    CreateMatchComponent,
    UpdatePlayerComponent,
    RankingComponent,
    PlayerMatchesComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule,
    CommonModule,
    BrowserAnimationsModule,
    SharedModule
  ],
  providers: [ 
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
