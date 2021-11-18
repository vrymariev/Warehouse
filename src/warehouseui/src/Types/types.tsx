export interface Manufacturer {
    id: number,
    name: string,
    country: Country
}

export interface Country {
    id: number,
    name: string,
}

export interface GoodType {
    id: number,
    name: string,
    category: string,
    count: number,
    manufacturerId: number,
    manufacturer?: Manufacturer,
    price: number,
    registrationDate: Date
}
