#!/bin/sh

jay -c FileParser.jay < skeleton._cs > FileParser.cs
jay -c InteractiveParser.jay < skeleton._cs > InteractiveParser.cs
