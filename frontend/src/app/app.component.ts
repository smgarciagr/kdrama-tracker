import { Component, OnInit } from '@angular/core';
import { Drama, DramaFilters, DramaStats, DramaStatus } from './models/drama.model';
import { DramaService } from './services/drama.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'] ,
  standalone: false
})
export class AppComponent implements OnInit {
  dramas: Drama[] = [];
  stats?: DramaStats;
  genres: string[] = [];
  filters: DramaFilters = { search: '', status: '', genre: '' };
  showForm = false;
  editingDrama?: Drama;

  form: Partial<Drama> = this.emptyForm();

  constructor(private service: DramaService) {}

  ngOnInit() {
    this.loadAll();
  }

  loadAll() {
    this.service.getAll(this.filters).subscribe(d => this.dramas = d);
    this.service.getStats().subscribe(s => this.stats = s);
    this.service.getGenres().subscribe(g => this.genres = g);
  }

  onFilter() {
    this.service.getAll(this.filters).subscribe(d => this.dramas = d);
  }

  openForm(drama?: Drama) {
    this.editingDrama = drama;
    this.form = drama ? { ...drama } : this.emptyForm();
    this.showForm = true;
  }

  closeForm() {
    this.showForm = false;
    this.editingDrama = undefined;
  }

  saveDrama() {
    if (!this.form.title || !this.form.genre || !this.form.episodes) return;

    if (this.editingDrama) {
      this.service.update(this.form as Drama).subscribe(() => {
        this.loadAll();
        this.closeForm();
      });
    } else {
      this.service.create(this.form as Omit<Drama, 'id' | 'createdAt'>).subscribe(() => {
        this.loadAll();
        this.closeForm();
      });
    }
  }

  deleteDrama(id: number) {
    if (confirm('¿Eliminar este drama?')) {
      this.service.delete(id).subscribe(() => this.loadAll());
    }
  }

  statusLabel(status: DramaStatus): string {
    return { PorVer: '📌 Por ver', Viendo: '▶️ Viendo', Terminado: '✅ Terminado' }[status];
  }

  getStars(rating: number): string {
    return '⭐'.repeat(Math.round(rating / 2));
  }

  private emptyForm(): Partial<Drama> {
    return { title: '', originalTitle: '', genre: '', episodes: 16, status: 'PorVer', year: undefined, rating: undefined, review: '', notes: '' };
  }
}