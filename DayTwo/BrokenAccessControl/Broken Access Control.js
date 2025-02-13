const express = require('express')
const app = express()
const port = 3000

app.use(express.json())

app.get('/grades', (req, res) => {
    const lookup = {}
    lookup.studentID = req.query.studentid
    lookup.subjectID = req.query.subjectid
    const grade = getGrade(lookup)
    res.json(grade)
})

app.patch('/grades', (req, res) => {
    const grade = {}
    grade.studentID = req.body.studentid
    grade.subjectID = req.body.subjectid
    grade.grade = req.body.grade
    const response = updateGrade(grade)
    res.json(response)
})

function getGrade(grade) {
    const fromDB = lookupGradeInDB(grade)
    return fromDB
}

function updateGrade(grade) {
    const status = updateGradeInDB(grade)
    return status 
}