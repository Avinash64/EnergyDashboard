<script setup>
import BarChart from "./BarChart.vue";
import Map from "./Map.vue";



</script>

<template>
    <div class="dashboard">
        <h1>Dashboard</h1>
        <div class="grid-container">
            <div class="grid-item grid-item1">
                <BarChart></BarChart>
            </div>
    <div class="grid-item grid-item2">
        <Map></Map>
    </div>
    <div class="grid-item grid-item3">Grid </div>
    <div class="grid-item grid-item4">Grid 2</div>
    <div class="grid-item grid-item5">Grid 2</div>
    <div class="grid-item grid-item6">Grid 2</div>
    <div class="grid-item grid-item7">Grid 2</div>
</div>
</div>
</template>


<style>
    .grid-container {
        display: grid;
        grid-template-columns: 1fr 1fr;
        grid-auto-rows: minmax(150px, auto);
        grid-gap: 10px;
        width: 100%;

    }
    .dashboard {
        width: 100%;
    }

    .grid-item {
        background-color: aquamarine;
        border-style: solid;
    }

    .grid-item2 {
        grid-column-start: 2;
        grid-column-end: 3;

        grid-row-start: 1;
        grid-row-end: 3;
    }
    .grid-item7 {
        grid-column-start: 1;
        grid-column-end: -1;
    }

    .grid-item1 {
        background-color: white;
    }
</style>