export class Competidor {
    id: string;
    titulo: string;
    decimal: string;
    nota: number;
    ano: number;
    urlImagem: string;
}

export type Competidores = Array<Competidor>;