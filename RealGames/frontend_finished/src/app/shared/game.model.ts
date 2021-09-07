export class Game {
   id: number;
   name: string;
   price: number;
   description: string;
   minReq: string;
   recReq: string;
   developerId: number;
   categoryId: number[];
   categoryName: string[];
   img: string;

  constructor(input?: any) {
    Object.assign(this, input);
  }
}
