export class Vault {
    constructor(data) {
        this.id = data.id
        this.creator = data.creator
        this.creatorId = data.creatorId
        this.name = data.name
        this.description = data.description
        this.img = data.img
        this.isPrivate = data.isPrivate
    }

}