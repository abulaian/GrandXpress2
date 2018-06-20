import { InMemoryDbService } from "angular-in-memory-web-api";

export class InMemTransService implements InMemoryDbService {
    createDb() {
        const transactions = [
            { id: 1, name: "omar babiker" },
            { id: 2, name: "ali shimo" },
            { id: 3, name: "nazar osman" },
            { id: 4, name: "hashim ali" }
        ];

        return { transactions };
    }
}