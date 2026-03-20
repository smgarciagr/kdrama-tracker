import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Drama, DramaFilters, DramaStats } from '../models/drama.model';

@Injectable({ providedIn: 'root' })
export class DramaService {
  private api = 'http://localhost:5000/api/dramas';

  constructor(private http: HttpClient) {}

  getAll(filters: DramaFilters = {}): Observable<Drama[]> {
    let params = new HttpParams();
    if (filters.search)  params = params.set('search', filters.search);
    if (filters.status)  params = params.set('status', filters.status);
    if (filters.genre)   params = params.set('genre', filters.genre);
    return this.http.get<Drama[]>(this.api, { params });
  }

  getById(id: number): Observable<Drama> {
    return this.http.get<Drama>(`${this.api}/${id}`);
  }

  create(drama: Omit<Drama, 'id' | 'createdAt'>): Observable<Drama> {
    return this.http.post<Drama>(this.api, drama);
  }

  update(drama: Drama): Observable<void> {
    return this.http.put<void>(`${this.api}/${drama.id}`, drama);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.api}/${id}`);
  }

  getGenres(): Observable<string[]> {
    return this.http.get<string[]>(`${this.api}/genres`);
  }

  getStats(): Observable<DramaStats> {
    return this.http.get<DramaStats>(`${this.api}/stats`);
  }
}
