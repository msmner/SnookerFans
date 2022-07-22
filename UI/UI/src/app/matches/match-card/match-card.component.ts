import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Match } from '../../models/Match';
import { MatchService } from '../../services/match.service';

@Component({
  selector: 'app-match-card',
  templateUrl: './match-card.component.html',
  styleUrls: ['./match-card.component.css']
})
export class MatchCardComponent implements OnInit {
  @Input() match!: Match;
  constructor(private matchService: MatchService, private router: Router) { }

  ngOnInit(): void {
  }

  delete() {
    this.matchService.deleteMatch(this.match.id).subscribe({
      complete: () => this.router.navigateByUrl('')
    });
  }
}
