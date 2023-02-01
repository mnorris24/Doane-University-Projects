const Joi = require('joi');
const express = require('express');
const app = express();

app.use(express.json());

const cards = [
    { id: 1, name: 'Mox Pearl', year: 1993, price: 1000},
    { id: 2, name: 'Jace, the Mind Sculptor', year: 2010, price: 45},
    { id: 3, name: 'Lightning Bolt', year: 1993, price: 3},
];

app.get('/', (req, res) => {
    res.send('This is my card collection API');
});

app.get('/api/cards', (req, res) => {
    res.send(cards);
});

app.post('/api/cards',( req, res) => {
    const { error } = validateCards(req.body); // result.error
    if (error) return res.status(400).send(error.details[0].message)


    const card = {
        id: cards.length + 1,
        name: req.body.name,
        year: req.body.year,
        price: req.body.price,
    };
    cards.push(card);
    res.send(card);
});

app.put('/api/cards/:id', (req, res) => {
    // Look up card
    // if not existing, return 404
    const card = cards.find(c => c.id === parseInt(req.params.id));
    if (!card) return res.status(404).send('The card with the given ID was not found');

    // Validate
    //if invalid, return 400 - bad request
    const { error } = validateCards(req.body); // result.error
    if (error) return res.status(400).send(error.details[0].message)

    // Update card
    card.name =  req.body.name;
    card.year = req.body.year;
    card.price = req.body.price;
    // Return the updated card
    res.send(card);

});

function validateCards(card) {
    const schema = {
        name: Joi.string().min(3).required(),
        year: Joi.required(),
        price: Joi.required(),
    };

    return Joi.validate(card, schema);
}

app.get('/api/cards/:id', (req, res) => {
   const card = cards.find(c => c.id === parseInt(req.params.id));
   if (!card) return res.status(404).send('The card with the given ID was not found'); //404
   res.send(card);
})

app.delete('/api/cards/:id', (req, res) => {
    // Look up card
    // Not existing, return 404
    const card = cards.find(c => c.id === parseInt(req.params.id));
    if (!card) return res.status(404).send('The card with the given ID was not found');

    // Delete
    const index = cards.indexOf(card);
    cards.splice(index, 1);

    //Return the same card
    res.send(card);


})

//PORT
const port = process.env.PORT || 3000;
app.listen(port, () => console.log(`Listening on port ${port}...`));
