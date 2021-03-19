import { CarImages } from "./carImages";

export interface CarDetailsDto{

    id:number;
    name:string,
    carName:string;
    brandName:string;
    dailyPrice:number;
    modelYear:number;
    description:string;
    imagePath:string;
    carImages:CarImages[];
  }

