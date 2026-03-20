export type DramaStatus = 'PorVer' | 'Viendo' | 'Terminado';

export interface Drama {
  id: number;
  title: string;
  originalTitle?: string;
  year?: number;
  genre: string;
  episodes: number;
  status: DramaStatus;
  rating?: number;
  review?: string;
  notes?: string;
  createdAt: string;
  updatedAt?: string;
}

export interface DramaStats {
  total: number;
  porVer: number;
  viendo: number;
  terminado: number;
  promedioRating: number;
}

export interface DramaFilters {
  search?: string;
  status?: DramaStatus | '';
  genre?: string;
}
