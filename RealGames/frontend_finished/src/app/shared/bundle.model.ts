export class Bundle {
  id: number;
  name: string;
  price: number;
  gameName: string[];
  gameId: number[];
  img: string;

  constructor(input?: any) {
    Object.assign(this, input);
  }
}
